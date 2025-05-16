extends Button

@export var level_1 = "res://scenes/levels/boss_level.tscn"
var level = load(level_1)

func _on_pressed() -> void:
	get_tree().change_scene_to_packed(level)
