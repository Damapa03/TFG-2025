class_name StateMachine extends Node

@export var currentState: State
@export var character: CharacterBody2D
@export var animationTree: AnimationTree

var states: Array

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	for child in get_children():
		if child is State:
			states.append(child)
			child.character = character
			child.playback = animationTree.get("parameters/playback")
			
			child.connect("interrupt_state", on_state_interrupt_state)

	


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if currentState.next_state != null:
		switch_states(currentState.next_state)
	currentState.state_process(delta)
	
func check_if_can_move() -> bool:
	return currentState.can_move

func switch_states(new_state: State):
	if currentState != null:
		currentState.on_exit();
		currentState.next_state = null;
	currentState = new_state
	currentState.on_enter()

func _input(event: InputEvent) -> void:
	currentState.state_input(event)
	
func on_state_interrupt_state(new_state: State):
	switch_states(new_state)
