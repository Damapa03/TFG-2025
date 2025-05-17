extends Node2D

var character: CharacterBody2D

@export var ring_scene: PackedScene
@export var gem_scene: PackedScene
@onready var gem_timer: Timer = $gem_timer
@export var punto_inicio: Vector2
@export var punto_final: Vector2
@export var character_spawn: Vector2
@export var duracion_movimiento: float = 1.5

@export var level_velocity: int = 40

var gem_num = 3

func _ready() -> void:
	character = Global.actual_character()
	character.global_position = character_spawn
	add_child(character)
	character.friction = 1600.0
	character.SPEED = 70

func _process(delta: float) -> void:
	character.velocity.x = character.velocity.x - 40
	if character.SPEED >= 600:
		character.SPEED = 600

func _on_ring_timer_timeout() -> void:
	var instancia = ring_scene.instantiate() as Node2D
	add_child(instancia)
	instancia.global_position = punto_inicio
	
	var tween = create_tween()
	tween.tween_property(instancia, "global_position", punto_final, duracion_movimiento)


func _on_gem_timer_timeout() -> void:
	if gem_num > 0:
		var instancia = gem_scene.instantiate() as Node2D
		add_child(instancia)
		instancia.global_position = punto_inicio
	
		var tween = create_tween()
		tween.tween_property(instancia, "global_position", punto_final, duracion_movimiento)
		gem_num -= 1
	else: 
		gem_timer.stop()
