extends CharacterBody2D

@export var _SPEED = 300
@export var hit_state: State

@onready var animationTree: AnimationTree = $AnimationTree
@onready var stateMachine: StateMachine = $EnemieStateMachine
@onready var original_position = global_position

var gravity = false


var SPEED = _SPEED


func _physics_process(delta: float) -> void:
	# Add the gravity.
	if gravity:
		velocity += get_gravity() * delta

	move_and_slide()


func _on_area_2d_body_entered(body: Node2D) -> void:
	stateMachine.switch_states(hit_state)
