extends Node2D

@onready var animatedSprite2D: AnimatedSprite2D = $AnimatedSprite2D
@onready var finish_timer: Timer = $Timer

var login_scene = preload("res://scenes/ui/login.tscn")

func _on_area_2d_body_entered(body: Node2D) -> void:
	animatedSprite2D.play("disappear")
	body.queue_free()


func _on_animated_sprite_2d_animation_finished() -> void:
	if animatedSprite2D.animation == "disappear":
		finish_timer.start()
		animatedSprite2D.visible = false


func _on_timer_timeout() -> void:
	print("Aaaa")
	get_tree().change_scene_to_packed(login_scene)
