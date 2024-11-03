# FaBIL - Fast Binary Image Labeler

Fast Binary Image Labeler is a free .NET 8 application designed to provide simple and fast binary image labeling.

![Screenshot](FastImageLabeler/assets/Screenshot.png)

## Features

- **Fast**:
Start the application and label images using your arrow keys.
Using arrow keys to label images is faster and more intuitive than using a mouse or touchpad.

- **Simple**: The application is designed to be simple and easy to use so you can go straight to the point and start lebelling images immediately.
- **Local State Persistence**: The application remembers the source and destination folders, so you can continue where you left off.
- **Fluid** Resize the window for a better view.

## How to Use

1. Set the label names;
2. Set the source folder. The destination folder will be created as a subfolder named `/Results`, where 3 other subfoders will be created: one for each label and one called `/Unknown`.
3. Click on the `Start` button or press `F5` to start labeling images.
4. Use the `LEFT` or `RIGHT` arrow keys to label images. The image will be moved to the corresponding label folder.
5. You can skip an image by pressing the `UP` or `DOWN` arrow keys.
6. The images are moved to their respective folders as you label them - no need to save or stop.
7. You can undo the last labeling by pressing `z`.
8. Click on the `Stop` button or press `ESC` to stop labeling images.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Contact

For any questions or suggestions, please open an issue or make a PR.
