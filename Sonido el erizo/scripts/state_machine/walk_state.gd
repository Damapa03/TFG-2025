class_name Walk_state extends State

@export var run_state: State
@export var air_state: State
@export var ground_state: State

@export var run_animation: String = "run"
@export var jump_animation: String = "rolling"


func state_process(delta: float):
	print(character.SPEED)
	character.SPEED += 20
	if character.SPEED >= 600:
		run()
	
	if character.velocity == Vector2.ZERO:
		character.SPEED = character._SPEED
		next_state = ground_state
		playback.start("Start")

func run():
	next_state = run_state
	playback.start(run_animation)

func state_input(event: InputEvent):
	if event.is_action_pressed("jump"):
		jump()

func jump():
	character.velocity.y = character.jumpVelocity
	next_state = air_state
	playback.travel(jump_animation)
