class_name CrouchState extends State

@export var spinDash_state: State
@export var ground_state: State

func state_input(event: InputEvent):
	if event.is_action_pressed("jump"):
		spinDash()
		
	if event.is_action_released("down"):
		next_state = ground_state

func on_exit():
	playback.travel("Start")

func spinDash():
	next_state = spinDash_state
