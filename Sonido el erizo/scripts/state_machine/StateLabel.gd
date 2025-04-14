class_name StateLabel extends Label

@export var statemachine: CharacterStateMachine
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	text = "State: " + statemachine.currentState.name
