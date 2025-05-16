extends State

func on_enter():
	character.get_node("Physic_Collider").queue_free()
	character.gravity = true
