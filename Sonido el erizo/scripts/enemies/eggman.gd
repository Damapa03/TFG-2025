extends CharacterBody2D

@export var state_machine: StateMachine
@export var hit_state: State

var health = 3

func on_timer_timeout():
	pass

func _on_area_2d_body_entered(body: Node2D) -> void:
	if health <= 0 :
		SignalBus.emit_signal("bossDefeat")
	else:
		health -= 1
		state_machine.switch_states(hit_state)
