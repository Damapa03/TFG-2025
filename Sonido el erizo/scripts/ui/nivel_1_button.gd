extends Button

@export var level_1 = "res://scenes/levels/world_1_1.tscn"
var level = load(level_1)

func _on_pressed() -> void:
	get_tree().change_scene_to_packed(level)
