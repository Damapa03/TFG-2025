class_name Run_State extends State

@export var air_state: State
@export var ground_state: State

@export var jump_animation: String = "rolling"

func state_process(delta: float):
	
	if character.SPEED >= 1000:
		character.SPEED = 1000
	else: character.SPEED += 20
		
	if character.velocity == Vector2.ZERO:
		character.SPEED = character._SPEED
		next_state = ground_state
		playback.start("Start")
func state_input(event: InputEvent):
	if event.is_action_pressed("jump"):
		jump()

func jump():
	character.velocity.y = character.jumpVelocity
	next_state = air_state
	playback.travel(jump_animation)
