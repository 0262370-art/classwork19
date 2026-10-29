# AI Use Declaration — Match the Object

## Project Information

**Project:** Match the Object  
**Course:** Virtual Reality  
**AI Usage Level:** Level 2 — Assisted Development  
**Engine:** Unity  
**Platform:** Meta Quest 2 / Meta Quest 3

### Team Members

| Name | GitHub Username |
|---|---|
| Fátima Walls | [fatimawalls](https://github.com/fatimawalls) |
| Regina López | [0262370-art](https://github.com/0262370-art) |

---

## 1. AI Tools Used

AI tools were used as development assistants during the creation of the Match the Object VR experience.

The assistance focused on understanding Unity and C# concepts, exploring implementation approaches, debugging scripts, and improving the organization of the project.

AI assistance was used for:

- Understanding how to modify GameObjects in Unity.
- Implementing shape, color, and size selection.
- Understanding quaternion-based rotation and angle comparison.
- Developing the reset functionality.
- Implementing the answer validation system.
- Improving the feedback provided to the user.
- Preparing project documentation.

AI-generated suggestions were reviewed and adapted to the project's requirements. The team was responsible for the final implementation, testing, and integration.

## 2. Relevant AI Prompts

The following prompts represent examples of the assistance used during development.

### Object Properties

> How can I create a Unity C# script that allows a GameObject to change between a cube, sphere, and cylinder, with different colors and sizes?

### Object Rotation

> How can I implement rotation controls around the X, Y, and Z axes using Unity C# and allow the user to modify the object's orientation?

### Random Target Generation

> How can I generate a random target object in Unity by selecting a random shape, color, size, and rotation?

### Object Reset

> How can I store an object's initial shape, color, size, and rotation in Unity and restore them when the user presses a reset button?

### Answer Validation

> How can I compare two GameObjects in Unity and check whether their shapes, colors, sizes, and rotations match? I want to use a rotation tolerance instead of requiring an exact quaternion match.

### User Feedback

> How can I display feedback using TextMeshPro in Unity to indicate whether the user's object matches the target, without revealing the correct configuration?

### Debugging and Development Support

> Help me review and troubleshoot my Unity C# scripts for a VR object-matching interaction. The scripts should support shape, color, size, rotation, reset, and answer confirmation.

*Note: These prompts are representative examples of the AI assistance used. They should be adjusted if the actual prompts used during development were different.*

## 3. Implementation Explanation

The project was developed in Unity using C# to create a virtual reality interaction in which the user modifies an object until it matches a randomly generated target.

The implementation is organized into two main scripts: `ObjectController` and `MatchManager`.

### ObjectController

The `ObjectController` script manages the visual properties and transformations of an object.

It includes the following functionality:

- **Shape Selection:** The object can change between a cube, sphere, and cylinder using the `ShapeType` enum and the corresponding mesh references.
- **Color Selection:** The object can be red, green, or blue using the `ColorType` enum.
- **Size Modification:** The object can be small, medium, or large using the `SizeType` enum.
- **Rotation:** The object can be rotated around the X, Y, and Z axes using the `RotateX()`, `RotateY()`, and `RotateZ()` methods.
- **Reset Functionality:** The original shape, color, size, and rotation are stored during initialization and restored through the `ResetObject()` method.
- **Visual Updates:** The `UpdateVisuals()` method updates the mesh, material color, and scale according to the object's current properties.

The script also creates an instance of the object's material to allow color modifications without directly changing the shared material.

### MatchManager

The `MatchManager` script controls the target generation, answer validation, and user feedback.

Its main responsibilities are:

- **Random Target Generation:** The `GenerateRandomTarget()` method randomly selects the target's shape, color, and size. It also generates a rotation using multiples of 90 degrees around the X, Y, and Z axes.
- **Answer Validation:** The `ConfirmAnswer()` method compares the player's object with the target object.
- **Shape, Color, and Size Comparison:** The script checks whether the selected properties match the target's properties.
- **Rotation Comparison:** The script uses `Quaternion.Angle()` to calculate the angular difference between the two objects.
- **Rotation Tolerance:** A configurable tolerance of 25 degrees is used to determine whether the orientations are sufficiently close.
- **User Feedback:** The interface displays a success message when the object matches the target. Otherwise, it identifies the incorrect properties without revealing the correct values.

The feedback is displayed using a TextMeshPro UI component. Successful answers display a green message, while incorrect answers display a red message identifying the properties that need to be corrected.

### Validation Logic

The answer is considered correct when the following conditions are satisfied:

1. The shape matches the target.
2. The color matches the target.
3. The size matches the target.
4. The angular difference between the rotations is within the configured tolerance.

The rotation comparison uses:

`Quaternion.Angle(playerObject.transform.localRotation, targetObject.transform.localRotation)`

This approach allows a degree of flexibility in the rotation comparison instead of requiring an exact match.

## 4. AI Contribution and Limitations

AI tools were used as assistants throughout the development process. They provided explanations, coding suggestions, debugging support, and documentation assistance.

The AI did not replace the team's responsibility for the project. Both team members were responsible for understanding the implementation, reviewing the code, testing the interaction, and ensuring that the final project met the assignment requirements.

AI-generated suggestions were reviewed and adapted when necessary. The final implementation decisions and project integration were performed by the team.

The use of AI followed the requirements of **AI Level 2 — Assisted Development**.

## 5. Declaration

We declare that AI tools were used as development assistants during the creation of the Match the Object VR project.

We acknowledge the use of AI assistance and take responsibility for the final implementation, documentation, and submitted project.
