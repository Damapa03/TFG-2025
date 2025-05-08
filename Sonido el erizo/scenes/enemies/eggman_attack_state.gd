extends State

@export var circular_attack_animation = "circular_attack"
@export var normal_attack_animation = "attack"

func _ready() -> void:
	SignalBus.bossAttack.connect(attack)

func attack(rnd):
	print("attack")
	print(rnd)
	ataque_atropello()
	#match rnd:
		#1:
			#circular_attack()
		#2:
			#ataque_atropello()
		#3:
			#ataque_golpetazo()

func circular_attack():
	print("Circulo")
	playback.start(circular_attack_animation)

func ataque_atropello():
	playback.start(normal_attack_animation)
	character.velocity.y += 500
	if character.is_on_floor():
		character.velocity.x += 1000
	
func ataque_golpetazo():
	playback.start(normal_attack_animation)
	pass
