class_name Ground_state extends State

@export var jumpVelocity = -400.0

@export var air_state: State
@export var crouch_state: State

@export var jump_animation: String = "jump"
@export var crouch_animation: String = "crouch"

@export var idle_timer: Timer
@export var idleAngry_timer: Timer


var afk = true

func state_process(delta:float):
	if character.velocity == Vector2.ZERO and afk:
		idle_timer.start()
		afk = false
	if character.velocity != Vector2.ZERO:
		idle_timer.stop()
		afk = true

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
	

func _on_idle_timer_timeout() -> void:
	playback.travel("idle")
	idleAngry_timer.start()


func _on_idle_angry_timer_timeout() -> void:
	playback.travel("idle_angry")
