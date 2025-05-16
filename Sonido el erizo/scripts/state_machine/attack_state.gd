class_name AttackState extends State

@export var homming_speed = 350
@export var steer_force = 50.0
@export var ground_state: State 

@onready var rotation = randf_range(-0.09, 0.09)

var acceleration = Vector2.ZERO
var target = null

func on_enter():
	var enemies = get_tree().get_nodes_in_group("Enemies")
	var objects = get_tree().get_nodes_in_group("Objects")
	
	var distances = []
	
	for enemy in enemies:
		distances.append(character.global_position.distance_squared_to(enemy.global_position))
	
	for objet in objects:
		distances.append(character.global_position.distance_squared_to(objet.global_position))
	
	var min_distance = distances.min()
	var min_index = distances.find(min_distance)
	target = enemies[min_index]
	
	seek()
	
func seek():
	var steer = Vector2.ZERO
	if target:
		var desired = (target.position - character.position).normalized() * homming_speed
		steer = (desired - character.velocity).normalized() * steer_force
	return steer

func state_process(delta: float):
	acceleration += seek()
	character.velocity += acceleration * delta
	character.velocity = character.velocity.limit_length(homming_speed)
	rotation = character.velocity.angle()
	character.position += character.velocity * delta
	
	if character.is_on_floor():
		pass
		next_state = ground_state
