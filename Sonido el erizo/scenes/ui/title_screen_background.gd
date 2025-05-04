extends Node2D

@onready var sonicGreetingAnim := $Parallax2D4/Sonic

# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	SignalBus.blackScreenOut.connect(startSonicAnim) 
	

func startSonicAnim():
	sonicGreetingAnim.play("default")
