extends State


func state_process(delta: float):
	character.velocity += character.get_gravity() * delta
