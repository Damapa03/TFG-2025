extends CharacterBody2D


@export var SPEED = 300.0

@onready var animationTree: AnimationTree = $AnimationTree
@onready var sprite2D: Sprite2D = $Sprite2D
#@onready var stateMachine: StateMachine = $StateMachine



func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := Input.get_axis("left", "right")
	if direction:
		velocity.x = direction * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
	
	if direction > 0:
		sprite2D.flip_h = false
	elif direction < 0:
		sprite2D.flip_h = true
	
	animationTree.set("parameters/move/blend_position", direction)
	


	move_and_slide()
