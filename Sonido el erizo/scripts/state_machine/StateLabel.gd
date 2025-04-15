class_name StateLabel extends Label

@export var statemachine: StateMachine
# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	text = "State: " + statemachine.currentState.name
