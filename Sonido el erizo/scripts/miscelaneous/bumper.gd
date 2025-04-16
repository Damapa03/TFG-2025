extends Node2D

@onready var sprite: AnimatedSprite2D = $AnimatedSprite2D
@export var character: CharacterBody2D

var reversed = true
var state_machine: StateMachine
var air_state: State 

func _ready() -> void:
	state_machine = character.get_node("StateMachine")
	air_state = state_machine.get_node("AirState")

func _on_area_2d_body_entered(body: Node2D) -> void:
	if body == character:
		sprite.play("Activated")
		character.velocity.y = -600
		reversed = false
		
		state_machine.switch_states(air_state)


func _on_animated_sprite_2d_animation_finished() -> void:
	if !reversed:
		sprite.play_backwards("Activated")
		reversed = true
