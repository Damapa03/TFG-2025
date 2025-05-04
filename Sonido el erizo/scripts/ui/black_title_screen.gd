extends Node2D


func _on_animated_sprite_2d_animation_finished() -> void:
	SignalBus.blackScreenOut.emit()
	queue_free()
