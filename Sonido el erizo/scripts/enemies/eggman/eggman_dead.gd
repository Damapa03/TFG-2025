extends State

func on_enter():
	character.get_node("Path2D/Circular Attack/Area2D").queue_free()
	character.gravity = true
