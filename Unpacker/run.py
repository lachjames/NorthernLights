# This tool takes a KotOR/TSL installation and "unpacks" it, turning it from a set of archives into a base set of files.
import tkinter as tk
import tkinter.filedialog

import unpack

root = tk.Tk()
root.geometry("800x600")

is_tsl = tk.BooleanVar(root)
input_folder = tk.StringVar(root)
input_folder.set("D:/SteamLibrary/SteamApps/common/swkotor")
output_folder = tk.StringVar(root)
output_folder.set("D:/KotOR/swkotor_dupl")
status_token = tk.StringVar(root)

is_tsl_checkbutton = tk.Checkbutton(root, text="Is TSL?", variable=is_tsl)
is_tsl_checkbutton.pack()

input_folder_lbl = tk.Label(root, textvariable=input_folder)
input_folder_lbl.pack()
input_folder_btn = tk.Button(root, text="Select Input Folder", command=lambda: input_folder.set(tk.filedialog.askdirectory()))
input_folder_btn.pack()

output_folder_lbl = tk.Label(root, textvariable=output_folder)
output_folder_lbl.pack()
output_folder_btn = tk.Button(root, text="Select Output Folder", command=lambda: output_folder.set(tk.filedialog.askdirectory()))
output_folder_btn.pack()

unpack_btn = tk.Button(root, text="Unpack", command=lambda: unpack.unpack(unpack.UnpackContext(
    input_folder.get(),
    output_folder.get(),
    is_tsl.get(),
    status_token,
    root
)))

unpack_btn.pack()

status_lbl = tk.Label(root, textvariable=status_token)
status_lbl.pack()

root.mainloop()
