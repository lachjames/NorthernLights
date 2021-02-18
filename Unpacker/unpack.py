import os
import shutil
import threading


# from checksumdir import dirhash


class UnpackContext:
    def __init__(self, input_folder, output_folder, game, status_token, root):
        self.input_folder = input_folder
        self.output_folder = output_folder
        self.game = game
        self.status_token = status_token
        self.root = root
        self.debug = False


def unpack(ctx):
    t = threading.Thread(
        target=unpack_fn,
        args=(ctx,)
    )
    t.start()


def unpack_fn(ctx):
    # Store the status token
    ctx.status_token.set("Beginning to unpack")
    ctx.root.update_idletasks()

    ctx.status_token.set("Clearing scratch folder")
    shutil.rmtree("scratch")
    os.makedirs("scratch")

    ctx.status_token.set("Copying extra files")
    ctx.root.update_idletasks()
    unpack_extra_files(ctx)

    ctx.status_token.set("Unpacking modules")
    ctx.root.update_idletasks()
    unpack_modules(ctx)

    if ctx.game == 0:
        ctx.status_token.set("Unpacking rims")
        ctx.root.update_idletasks()
        unpack_rims(ctx)

    ctx.status_token.set("Unpacking data bifs")
    ctx.root.update_idletasks()
    unpack_data(ctx)

    ctx.status_token.set("Copying audio")
    ctx.root.update_idletasks()
    unpack_sounds(ctx)

    ctx.status_token.set("Copying textures")
    ctx.root.update_idletasks()
    unpack_textures(ctx)

    ctx.status_token.set("Copying lips")
    ctx.root.update_idletasks()
    unpack_lips(ctx)

    ctx.status_token.set("Copying movies")
    ctx.root.update_idletasks()
    unpack_movies(ctx)

    ctx.status_token.set("Copying override")
    ctx.root.update_idletasks()
    unpack_override(ctx)

    ctx.status_token.set("Done")
    ctx.root.update_idletasks()


def unpack_rim(ctx, from_file, to_folder):
    unpack_xt(ctx, from_file, to_folder, "/xt/unrim e ")


def unpack_erf(ctx, from_file, to_folder):
    unpack_xt(ctx, from_file, to_folder, "xt/unerf e ")


def unpack_keybif(ctx, from_file, to_folder):
    unpack_xt(ctx, from_file, to_folder, "xt/unkeybif e ", " \"" + ctx.input_folder + "/chitin.key\"")


def unpack_xt(ctx, from_file, to_folder, command, suffix=""):
    if not os.path.exists(from_file):
        print("Skipping " + from_file + " as does not exist")
        return

    cur_dir = os.getcwd() + "/"
    os.chdir(cur_dir + "/scratch")

    print(cur_dir + command + from_file + suffix)
    # Unpack the files
    os.system(cur_dir + command + "\"" + from_file + "\"" + suffix)

    # Move the files to the new folder
    for file in os.listdir(cur_dir + "/scratch/"):
        shutil.move(cur_dir + "/scratch/" + file, to_folder + file)

    os.chdir(cur_dir)


def unpack_modules(ctx):
    module_folder = ctx.input_folder + "/modules/"

    modules = set()

    for file in os.listdir(module_folder):
        if (file.endswith(".rim") and not file.endswith("_s.rim")) or file.endswith(".mod"):
            modules.add(file.split(".")[0].lower())

        full_name = module_folder + file
        print(full_name)

    print(modules)

    # Create the module directory in the output folder
    os.makedirs(ctx.output_folder + "/modules/")

    i = 0
    for module in modules:
        ctx.status_token.set("Unpacking module " + module + " (" + str(i) + "/" + str(len(modules)) + ")")

        to_dir = ctx.output_folder + "/modules/" + module + "/"
        os.makedirs(to_dir)

        # Get module.rim
        unpack_rim(ctx, ctx.input_folder + "/modules/" + module + ".rim", to_dir)

        # Unpack module_s.rim
        unpack_rim(ctx, ctx.input_folder + "/modules/" + module + "_s.rim", to_dir)

        # Unpack module_dlg.erf
        unpack_erf(ctx, ctx.input_folder + "/modules/" + module + "_dlg.erf", to_dir)

        # Unpack module.mod
        unpack_erf(ctx, ctx.input_folder + "/modules/" + module + ".mod", to_dir)

        i += 1
        if ctx.debug:
            break


def unpack_data(ctx):
    data_folder = ctx.input_folder + "/data/"
    os.makedirs(ctx.output_folder + "/data/")

    i = 0
    files = list(os.listdir(data_folder))
    for file in files:
        ctx.status_token.set("Unpacking data bif " + file + " (" + str(i) + "/" + str(len(files)) + ")")

        out_folder = ctx.output_folder + "/data/" + file.split(".")[0] + "/"
        os.makedirs(out_folder)

        unpack_keybif(ctx, data_folder + file, out_folder)

        i += 1
        if ctx.debug:
            break


def unpack_rims(ctx):
    rim_folder = ctx.input_folder + "/rims/"

    os.makedirs(ctx.output_folder + "/rims/")

    i = 0
    files = list(os.listdir(rim_folder))
    for file in files:
        ctx.status_token.set("Unpacking rim " + file + " (" + str(i) + "/" + str(len(files)) + ")")

        out_folder = ctx.output_folder + "/rims/" + file.split(".")[0] + "/"
        os.makedirs(out_folder)

        unpack_rim(ctx, rim_folder + file, out_folder)

        i += 1
        if ctx.debug:
            break


def unpack_sounds(ctx):
    # Music
    shutil.copytree(ctx.input_folder + "/streammusic/", ctx.output_folder + "/music/")

    if ctx.debug:
        return

    # Sound effects
    shutil.copytree(ctx.input_folder + "/streamsounds/", ctx.output_folder + "/sfx/")

    # Voiceover
    if ctx.game == 0:
        shutil.copytree(ctx.input_folder + "/streamwaves/", ctx.output_folder + "/vo/")
    else:
        shutil.copytree(ctx.input_folder + "/streamvoice/", ctx.output_folder + "/vo/")


def unpack_textures(ctx):
    os.makedirs(ctx.output_folder + "/textures/gui/")
    unpack_erf(ctx, ctx.input_folder + "/TexturePacks/swpc_tex_gui.erf", ctx.output_folder + "/textures/gui/")

    os.makedirs(ctx.output_folder + "/textures/tpa/")
    unpack_erf(ctx, ctx.input_folder + "/TexturePacks/swpc_tex_tpa.erf", ctx.output_folder + "/textures/tpa/")

    os.makedirs(ctx.output_folder + "/textures/tpb/")
    unpack_erf(ctx, ctx.input_folder + "/TexturePacks/swpc_tex_tpb.erf", ctx.output_folder + "/textures/tpb/")

    os.makedirs(ctx.output_folder + "/textures/tpc/")
    unpack_erf(ctx, ctx.input_folder + "/TexturePacks/swpc_tex_tpc.erf", ctx.output_folder + "/textures/tpc/")


def unpack_lips(ctx):
    lips_folder = ctx.input_folder + "/lips/"

    modules = set()
    for file in os.listdir(lips_folder):
        if file.endswith(".mod"):
            modules.add(file.split(".")[0])
        full_name = lips_folder + file
        print(full_name)

    for module in modules:
        os.makedirs(ctx.output_folder + "/lips/" + module + "/")
        unpack_erf(ctx, ctx.input_folder + "/lips/" + module + ".mod", ctx.output_folder + "/lips/" + module + "/")

        if ctx.debug:
            break


def unpack_movies(ctx):
    shutil.copytree(ctx.input_folder + "/movies/", ctx.output_folder + "/movies/")


def unpack_override(ctx):
    shutil.copytree(ctx.input_folder + "/override/", ctx.output_folder + "/override/")


def unpack_extra_files(ctx):
    shutil.copyfile(ctx.input_folder + "/dialog.tlk", ctx.output_folder + "/dialog.tlk")
    shutil.copyfile(ctx.input_folder + "/chitin.key", ctx.output_folder + "/chitin.key")


def unpack_all(ctx, from_folder, to_folder, unpack_func):
    os.makedirs(to_folder)

    i = 0
    files = list(os.listdir(from_folder))
    for file in files:
        ctx.status_token.set("Unpacking " + file + " (" + str(i) + "/" + str(len(files)) + ")")

        out_folder = ctx.output_folder + "/" + file.split(".")[0] + "/"
        os.makedirs(out_folder)

        unpack_func(ctx, from_folder + file, out_folder)

        i += 1
        if ctx.debug:
            break
