extends Button

@onready var userInputText: TextEdit = $"../UserInputText"
@onready var passWordInputText: TextEdit = $"../PasswordInputText"

var menu = preload("res://scenes/testin.tscn").instantiate()



func _on_pressed() -> void:
	if userInputText.text.is_empty() and passWordInputText.text.is_empty():
		pass
	else:
		get_tree().root.add_child(menu)
