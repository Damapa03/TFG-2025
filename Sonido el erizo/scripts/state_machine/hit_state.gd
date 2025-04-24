class_name Hit_state extends State

@export var dead_state: State
@export var stateMachine: StateMachine
@export var hit_animation: String = "hurt"

func on_enter():
	stateMachine.currentState = self
	playback.start(hit_animation)
	stateMachine.switch_states(dead_state)


func _on_animation_tree_animation_finished(anim_name: StringName) -> void:
	if anim_name == "hurt":
		character.queue_free()
