extends Node2D

@onready var animatedSprite2D: AnimatedSprite2D = $AnimatedSprite2D
@onready var timer: Timer = $Timer

func _on_area_2d_body_entered(body: Node2D) -> void:
	if animatedSprite2D.animation != "Finish":
		animatedSprite2D.play("Spin")
		timer.start()


func _on_timer_timeout() -> void:
	animatedSprite2D.play("Finish")
