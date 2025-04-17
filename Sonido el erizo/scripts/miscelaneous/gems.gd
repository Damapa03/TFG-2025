extends Node2D

# Obtiene el sprite animado cuando este listo y empezara la animacion por defecto
@onready var sprite: AnimatedSprite2D = $AnimatedSprite2D

# Al entrar un cuerpo en el area 2D empezara la animacion vanish
func _on_area_2d_body_entered(_body: Node2D) -> void:
	sprite.play("vanish")

# Cuando termine una animacion si esta es vanish hara que la gema desaparezca de la escena
func _on_animated_sprite_2d_animation_finished() -> void:
	if sprite.animation == "vanish":
		queue_free()
