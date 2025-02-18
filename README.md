# Simple 3D Platformer

A basic third-person platformer developed in Unity as per Lab 3 for COSC 416: Game Development. The player can move, jump (with double jump), dash, and collect coins for points. Features include a free-look camera, an environment with platforms, and a score system that updates via UI.

---

## Demo Video

Watch the gameplay demo here:  
[**YouTube Demo Link**](https://youtu.be/QIQc7hd-BN0)

---

## Overview

This project demonstrates a simple 3D platformer where the player navigates a series of boxes and platforms, collecting rotating coins. The camera is controlled via a third-person free-look setup, and movement is relative to the camera’s forward direction. 

---

## Features

- **Third-Person Free-Look Camera**  
  The camera orbits around the player, allowing you to view from different angles.
  
- **Camera-Based Movement**  
  The player moves relative to the camera’s orientation (WASD/arrow keys).
  
- **Jumping & Double Jump**  
  - Press `Space` to jump.  
  - You can jump again in mid-air for a double jump (resets on landing).
  
- **Dash**  
  - Press `Q` to dash forward for a short burst.
  
- **Coins**  
  - Rotating coins placed on top of various boxes/platforms.  
  - Collect them to earn points.  
  - Score is displayed on the UI.
  
- **Environment**  
  - Large flat plane as a base.  
  - Elevated boxes to jump onto.  
  - Invisible walls around the perimeter to prevent falling off.
  
- **Score System**  
  - Collecting a coin increments the score.  
  - The UI in the top-right corner displays the current score in real-time.

---

## Controls

- **W / A / S / D**: Move the player (relative to the camera).  
- **Space**: Jump (press again in mid-air for double jump).  
- **Mouse Movement**: Rotate the camera around the player (using Cinemachine or a free-look setup).  
- **Q**: Dash (short forward burst).

---
