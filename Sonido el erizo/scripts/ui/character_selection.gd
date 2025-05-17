extends Control



func _on_tails_selection_pressed() -> void:
	changeCharacter("tails")


func _on_knuckles_selection_pressed() -> void:
	changeCharacter("knuckles")



func _on_sonic_selection_pressed() -> void:
	changeCharacter("sonic")

func changeCharacter(character: String):
	Global.character = character
	get_tree().change_scene_to_file("res://scenes/ui/levelSelecction.tscn")
