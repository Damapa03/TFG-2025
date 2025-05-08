extends Node2D

@onready var character: CharacterBody2D = $sonic

@export var level_velocity: int = 40

func _ready() -> void:
	character.friction = 1600.0
	character.SPEED = 70

func _process(delta: float) -> void:
	character.velocity.x = character.velocity.x - 40
	if character.SPEED >= 600:
		character.SPEED = 600
