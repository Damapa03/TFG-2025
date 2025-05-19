class_name AttackState extends State

@export var homming_speed = 350
@export var steer_force = 50.0
@export var ground_state: State 
@export var area2d: Area2D

@onready var rotation = randf_range(-0.09, 0.09)

var acceleration = Vector2.ZERO
var target = null

func on_enter():
	var distances = []
	
	for body in area2d.get_overlapping_areas():
		distances.append(body.global_position)
	
	var min_distance = distances.min()
	target = min_distance
	
	
func seek():
	var steer = Vector2.ZERO
	if target:
		var desired = (target - character.position).normalized() * homming_speed
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
