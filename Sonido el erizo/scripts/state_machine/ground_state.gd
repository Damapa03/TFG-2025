class_name Ground_state extends State

@export var jumpVelocity = -400.0

@export var air_state: State
@export var crouch_state: State

@export var jump_animation: String = "jump"
@export var crouch_animation: String = "crouch"

func state_input(event: InputEvent):
	if event.is_action_pressed("jump"):
		jump()
	
	if event.is_action_pressed("down"):
		crouch()


func crouch():
	next_state = crouch_state
	playback.travel(crouch_animation)

func jump():
	character.velocity.y = jumpVelocity
	next_state = air_state
	playback.travel(jump_animation)
	
