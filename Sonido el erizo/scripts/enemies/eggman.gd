extends CharacterBody2D

@export var state_machine: StateMachine
@export var hit_state: State

var health = 3

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass


func _on_area_2d_body_entered(body: Node2D) -> void:
	if health <= 0 :
		SignalBus.emit_signal("bossDefeat")
	else:
		health -= 1
		state_machine.switch_states(hit_state)
