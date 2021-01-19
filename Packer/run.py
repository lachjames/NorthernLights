# This tool takes a KotOR/TSL installation and "unpacks" it, turning it from a set of archives into a base set of files.
import tkinter as tk
import tkinter.filedialog
import os
import shutil
import subprocess


def pack_module():
    from_folder = input_folder.get()
    to_file = output_location.get()

    if not os.path.exists(from_folder):
        raise Exception("Failed to load folder " + from_folder)

    cur_dir = os.getcwd() + "/"
    os.chdir(cur_dir + "/scratch")

    # Clear the scratch folder
    for file in os.listdir(cur_dir + "/scratch"):
        raise Exception("Scratch folder not empty - please clear it!")

    filenames = []
    # Copy the files from "from_folder" to the current folder
    for file in os.listdir(from_folder):
        shutil.copyfile(from_folder + "/" + file, cur_dir + "/scratch/" + file)
        filenames += [file]

    # Package up all files in the scratch folder into a mod file
    subprocess.run([
        cur_dir + "xt\\erf",
        "--mod",
        cur_dir + "/scratch/tmp.mod"
    ] + filenames)

    # Copy the mod file to the selected location
    shutil.copyfile(cur_dir + "/scratch/tmp.mod", to_file)

    # Clear the scratch folder
    for file in os.listdir(cur_dir + "/scratch"):
        os.remove(cur_dir + "/scratch/" + file)

    os.chdir(cur_dir)


root = tk.Tk()
root.geometry("800x600")

is_tsl = tk.BooleanVar(root)
input_folder = tk.StringVar(root)
input_folder.set("D:/KOTOR/kotor1_files/modules/danm13")
output_location = tk.StringVar(root)
output_location.set("D:/KOTOR/kotor1_files/module.mod")
status_token = tk.StringVar(root)

is_tsl_checkbutton = tk.Checkbutton(root, text="Is TSL?", variable=is_tsl)
is_tsl_checkbutton.pack()

input_folder_lbl = tk.Label(root, textvariable=input_folder)
input_folder_lbl.pack()
input_folder_btn = tk.Button(root, text="Select Input Folder", command=lambda: input_folder.set(tk.filedialog.askdirectory()))
input_folder_btn.pack()

output_location_lbl = tk.Label(root, textvariable=output_location)
output_location_lbl.pack()
output_location_btn = tk.Button(root, text="Select Output Location", command=lambda: output_location.set(tk.filedialog.asksaveasfilename()))
output_location_btn.pack()

unpack_btn = tk.Button(root, text="Pack Module", command=pack_module)

unpack_btn.pack()

status_lbl = tk.Label(root, textvariable=status_token)
status_lbl.pack()

root.mainloop()
