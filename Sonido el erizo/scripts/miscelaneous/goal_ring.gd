extends Node2D

@onready var animatedSprite2D: AnimatedSprite2D = $AnimatedSprite2D

#var login_scene = preload("res://scenes/ui/login.tscn")

func _on_area_2d_body_entered(body: Node2D) -> void:
	animatedSprite2D.play("disappear")
	body.queue_free()


func _on_animated_sprite_2d_animation_finished() -> void:
	if animatedSprite2D.animation == "disappear":
		queue_free()
		#get_tree().change_scene_to_packed(login_scene)
