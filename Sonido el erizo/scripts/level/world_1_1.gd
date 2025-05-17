extends Node2D

var character: CharacterBody2D

@export var character_spawn: Vector2

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	character = Global.actual_character()
	character.global_position = character_spawn
	add_child(character)
	SignalBus.emit_signal("on_character_ready")
