extends Node

var total_rings = 0
var rings = 0
var character = "sonic"

# Chracters Scenes
var sonic_scene := preload("res://scenes/characters/sonic.tscn").instantiate()
var knucles_scene := preload("res://scenes/characters/knuckles.tscn").instantiate()
var tails_scene := preload("res://scenes/characters/tails.tscn").instantiate()

func actual_character():
	match character:
		"sonic": 
			return sonic_scene
		"knuckles":
			return knucles_scene
		"tails":
			return tails_scene
	return ""
