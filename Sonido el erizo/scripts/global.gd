extends Node

var total_rings = 0
var rings = 0
var character = "sonic"

# Chracters Scenes
var sonic := preload("res://scenes/characters/sonic.tscn").instantiate()
var knucles_scene: PackedScene
#var tails_scene := preload("").instantiate()

func actual_character():
	match character:
		"sonic": 
			return sonic
		"knucles":
			return ""
		"tails":
			return ""
	return ""
