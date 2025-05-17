extends State

@export var circular_attack_animation = "circular_attack"
@export var sweep_attack_animation = "sweep_attack"
@export var drop_attack_animation = "drop_attack"
@export var walk_state: State

var attack_start = true
var rnd

func _ready() -> void:
	rnd = SignalBus.bossAttack.connect(attack)

func state_process(float):
	attack(rnd)
	if character.position != character.original_position and character.is_on_wall() and character.velocity == Vector2.ZERO:
		to_origin()

func attack(rnd):
	print(rnd)
	
	match rnd:
		1:
			circular_attack()
		2:
			ataque_atropello()
		3:
			ataque_golpetazo()

func circular_attack():
	print("Circulo")
	playback.start(circular_attack_animation)
	var duracion = playback.get_current_length()
	await get_tree().create_timer(duracion).timeout
	to_origin()


func ataque_atropello():
	playback.start(sweep_attack_animation)
	var duracion = playback.get_current_length()
	await get_tree().create_timer(duracion).timeout
	to_origin()

	
func ataque_golpetazo():
	playback.start(drop_attack_animation)
	var duracion = playback.get_current_length()
	await get_tree().create_timer(duracion).timeout
	to_origin()
	
func to_origin():
	next_state = walk_state
