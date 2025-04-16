extends Node2D

@onready var sprite: AnimatedSprite2D = $AnimatedSprite2D

func _on_area_2d_body_entered(_body: Node2D) -> void:
	print("good kbron")
	sprite.play("vanish")


func _on_animated_sprite_2d_animation_finished() -> void:
	if sprite.animation == "vanish":
		queue_free()
