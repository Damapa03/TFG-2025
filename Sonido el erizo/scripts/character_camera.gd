extends Camera2D

@onready var target := get_parent().get_node("sonic")
@export var follow_speed := 5.0

func _process(delta):
	if target:
		global_position = global_position.lerp(target.global_position, follow_speed * delta)
