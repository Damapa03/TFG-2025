extends State

@onready var timer: Timer = get_parent().get_parent().get_node("Timer")
@onready var rnd = RandomNumberGenerator.new()

@export var attack_state: State

func random_attack():
	return rnd.randi_range(1,3)

func _ready() -> void:
	timer.start()

func on_enter():
	timer.start()

func _on_timer_timeout() -> void:
	SignalBus.emit_signal("bossAttack",random_attack())
	next_state = attack_state
