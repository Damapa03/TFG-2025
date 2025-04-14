class_name State extends Node


@export var can_move: bool = false
signal interrupt_state(new_state: State)

var character: CharacterBody2D
var next_state: State
var playback: AnimationNodeStateMachinePlayback

func state_process(delta: float) -> void:
	pass	

func state_input(event: InputEvent) -> void:
	pass

func on_enter() -> void:
	pass

func on_exit() -> void:
	pass
