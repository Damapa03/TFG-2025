extends CharacterBody2D


@export var SPEED = 40.0
@export var hit_state: State
@export var sprite2D: Sprite2D
@export var rayCastRight: RayCast2D
@export var rayCastLeft: RayCast2D
@export var rayCastDownRight: RayCast2D
@export var rayCastDownLeft: RayCast2D

@onready var stateMachine: StateMachine = $EnemieStateMachine

var start_move_direction: Vector2 = Vector2.LEFT
var facint = 1


func _physics_process(delta: float) -> void:
	# Add the gravity.
	if not is_on_floor():
		velocity += get_gravity() * delta

	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	var direction := start_move_direction
	
	if direction != Vector2.ZERO and stateMachine.check_if_can_move():
		velocity.x = direction.x * facint * SPEED 
	elif stateMachine.currentState != hit_state:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		
	if rayCastRight.is_colliding():
		sprite2D.flip_h = true
		facint = 1

	if rayCastLeft.is_colliding():
		sprite2D.flip_h = false;
		facint = -1

	if !rayCastDownRight.is_colliding():
		sprite2D.flip_h = true
		facint = 1

	if !rayCastDownLeft.is_colliding():
		sprite2D.flip_h = false
		facint = -1

	move_and_slide()


func _on_area_2d_body_entered(body: Node2D) -> void:
	stateMachine.switch_states(hit_state)
