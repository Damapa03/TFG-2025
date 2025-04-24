class_name Character_hit_state extends State

@export var hit_animation: String = "hurt"

var rings = 1


func on_enter():
	print("hit enter")
	playback.start(hit_animation)
	
	if rings > 0:
		knockback()

func knockback():
	character.velocity = Vector2.ZERO  # Detiene el movimiento actual

	var direction := -1 if character.sprite2D.flip_h else 1
	var knockbackUp_force = 300  # Puedes ajustar este valor
	var knockback_force = 300
	# Empuja hacia atrás dependiendo de la dirección que mira
	character.velocity.x = -direction * knockback_force
	character.velocity.y = direction * knockbackUp_force
