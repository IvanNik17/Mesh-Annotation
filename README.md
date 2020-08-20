# Mesh-Annotation
A prototype for a manual mesh annotation tool, build in Unity. It can be used to mark vertices with different color for creation of manual masking, annotations or segmentation for ground truth data.

The application has been used to capture the ground truth data presented here - [GGG - Rough or Noisy? Metrics for Noise Detection in SfM Reconstructions](https://data.mendeley.com/datasets/xtv5y29xvz/1)

The implementation comes with a 3D reconstructed mesh of a stone bird bath for testing. For testing with other objects, just import the them in the Unity project and in the Manager object change the **Target** object in both scripts to the the appropriate object. 

# Controls
The prototype has a number of functionalities accessable using different keys:

1. A normal mouse orbit script is implemented used for rotating, moving and zooming the camera. The camera rotation and movement is done when the Right mouse button is held, while the zoom is done with the middle mouse button
2. Drawing on the surface on the object is done with the left mouse button and mouse pointer
3. "\[" and "\]" are used to change the size of the brush for drawing on the surface
4. Pressing Q changes the brush to an eraser to remove annotated parts of the mesh
5. By using 1,2,3 keys different annotation labels can be set for a manual multi-label segmentation
6. By pressing L, one of three different lights connected to the camera can be selected, to better see surface roughness or smaller parts of the mesh
7. NUMPAD 1 and 2, changes the light intensity, when parts of the object are too dark
8. NUMPAD + and -, changes the local scale of the object to easier work on very small or very large objects
9. Pressing S saves the annotation into a .txt file containing on each row the annotation for each pixel - 0 for no annotation and 1,2,3 for different labels

For running the project you will need Unity 2019.3.7f1 or higher.
