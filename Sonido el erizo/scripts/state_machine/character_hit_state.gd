class_name Character_hit_state extends State

@export var hit_animation: String = "hurt"
@export var ground_state: State

var rings = 1


func on_enter():
	print("hit enter")
	playback.start(hit_animation)
	
	if rings > 0:
		knockback()
		
func state_process(delta: float):
	if character.is_on_floor():
		print("to ground")
		next_state = ground_state

func knockback():
	character.velocity = Vector2.ZERO  # Detiene el movimiento actual

	var direction := -1 if character.sprite2D.flip_h else 1
	var knockback_force_y = -300  # Puedes ajustar este valor
	var knockback_force_x = 1000
	# Empuja hacia atrás dependiendo de la dirección que mira
	character.velocity.x = -direction * knockback_force_x
	character.velocity.y = knockback_force_y
