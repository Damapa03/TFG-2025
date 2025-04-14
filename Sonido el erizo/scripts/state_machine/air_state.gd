class_name AirState extends State

@export var ground_state: State
@export var attack_state: State

func state_process(delta: float) -> void:
	if character.is_on_floor():
		next_state = ground_state

func state_input(event: InputEvent):
	if event.is_action_pressed("jump"):
		next_state = attack_state
