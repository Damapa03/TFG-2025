extends Camera2D

var target
@export var follow_speed := 5.0

func _ready() -> void:
	SignalBus.on_character_ready.connect(connect_camera)

func _process(delta):
	if target:
		global_position = global_position.lerp(target.global_position, follow_speed * delta)

func connect_camera():
	target = get_tree().get_nodes_in_group("jugador")[0]
