class_name Character_dead_state extends State

@export var death_animation: String = "dead"

@onready var death_timer: Timer = $Death_timer

func on_enter():
	playback.start(death_animation)
	


func _on_death_timer_timeout() -> void:
	Engine.time_scale = 1
	get_tree().change_scene_to_file("res://scenes/ui/login.tscn")


func _on_animation_tree_animation_finished(anim_name: StringName) -> void:
	if anim_name == "dead":
		Engine.time_scale = 0.5
		character.get_node("CollisionShape2D").queue_free()
		death_timer.start()
