
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG"
ASSEMBLY = bin/Debug/XamlPreviewer.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Debug

XAMLPREVIEWER_EXE_MDB_SOURCE=bin/Debug/XamlPreviewer.exe.mdb
XAMLPREVIEWER_EXE_MDB=$(BUILD_DIR)/XamlPreviewer.exe.mdb
APPMANIFEST_XAML_SOURCE=AppManifest.xaml
START_XAML_SOURCE=start.xaml
MOONLIGHT_GTK_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll
SYSTEM_WINDOWS_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.Browser.dll
MOON_WINDOWS_DESKTOP_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES = 
BUILD_DIR = bin/Release

XAMLPREVIEWER_EXE_MDB=
APPMANIFEST_XAML_SOURCE=AppManifest.xaml
START_XAML_SOURCE=start.xaml
MOONLIGHT_GTK_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll
SYSTEM_WINDOWS_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/System.Windows.Browser.dll
MOON_WINDOWS_DESKTOP_DLL_SOURCE=../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(XAMLPREVIEWER_EXE_MDB) \
	$(APPMANIFEST_XAML) \
	$(START_XAML) \
	$(MOONLIGHT_GTK_DLL) \
	$(SYSTEM_WINDOWS_DLL) \
	$(SYSTEM_WINDOWS_BROWSER_DLL) \
	$(MOON_WINDOWS_DESKTOP_DLL)  

BINARIES = \
	$(XAMLPREVIEWER)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES =  \
	AssemblyInfo.cs \
	gtk-gui/generated.cs \
	gtk-gui/MainWindow.cs \
	gtk-gui/XamlPreviewer.XamlPanel.cs \
	Main.cs \
	MainWindow.cs \
	XamlPanel.cs 

DATA_FILES = 

RESOURCES = gtk-gui/gui.stetic 

EXTRAS = \
	AppManifest.xaml \
	start.xaml \
	xamlpreviewer.in 

REFERENCES =  \
	../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll \
	../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../usr/lib/mono/moonlight/System.Windows.dll \
	Mono.Posix \
	-pkg:glade-sharp-2.0 \
	-pkg:glib-sharp-2.0 \
	-pkg:gtk-sharp-2.0 \
	-pkg:gtksourceview2-sharp \
	System

DLL_REFERENCES =  \
	../../../../../../usr/lib/mono/moonlight/Moonlight.Gtk.dll \
	../../../../../../usr/lib/mono/moonlight/System.Windows.dll \
	../../../../../../usr/lib/mono/moonlight/Moon.Windows.Desktop.dll

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

APPMANIFEST_XAML = $(BUILD_DIR)/AppManifest.xaml
START_XAML = $(BUILD_DIR)/start.xaml
MOONLIGHT_GTK_DLL = $(BUILD_DIR)/Moonlight.Gtk.dll
SYSTEM_WINDOWS_DLL = $(BUILD_DIR)/System.Windows.dll
SYSTEM_WINDOWS_BROWSER_DLL = $(BUILD_DIR)/System.Windows.Browser.dll
MOON_WINDOWS_DESKTOP_DLL = $(BUILD_DIR)/Moon.Windows.Desktop.dll
XAMLPREVIEWER = $(BUILD_DIR)/xamlpreviewer

$(eval $(call emit-deploy-target,APPMANIFEST_XAML))
$(eval $(call emit-deploy-target,START_XAML))
$(eval $(call emit-deploy-target,MOONLIGHT_GTK_DLL))
$(eval $(call emit-deploy-target,SYSTEM_WINDOWS_DLL))
$(eval $(call emit-deploy-target,SYSTEM_WINDOWS_BROWSER_DLL))
$(eval $(call emit-deploy-target,MOON_WINDOWS_DESKTOP_DLL))
$(eval $(call emit-deploy-wrapper,XAMLPREVIEWER,xamlpreviewer,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
