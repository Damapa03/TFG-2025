extends State

@onready var timer: Timer = $Timer

@export var spinDashAnimation: String = "spin_dash"
@export var run_state: State

var boost = 300

func on_enter():
	playback.start(spinDashAnimation)
	
func state_input(event: InputEvent):
	if event.is_action("jump"):
		playback.start(spinDashAnimation)
		boost *= 20
		timer.start()


func _on_timer_timeout() -> void:
	character.velocity.x = boost
	next_state = run_state
