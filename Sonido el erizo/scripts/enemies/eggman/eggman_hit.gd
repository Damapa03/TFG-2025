extends State

@export var dead_state: State
@export var walk_state: State

var health = 3

func on_enter():
	if health <= 0 and character.stateMachine.currentState.name != dead_state.name:
		print("dead")
		next_state = dead_state
	else:
		health -= 1
		next_state = walk_state
