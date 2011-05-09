
EXTRA_DIST =  

# Warning: This is an automatically generated file, do not edit!

if ENABLE_DEBUG_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Debug/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Debug/Views.dll \
	../ViewModels/bin/Debug/ViewModels.dll
BUILD_DIR = bin/Debug

APPMANIFEST_XAML_SOURCE=appmanifest.xaml
VIEWS_DLL_SOURCE=../Views/bin/Debug/Views.dll
VIEWS_DLL_MDB_SOURCE=../Views/bin/Debug/Views.dll.mdb
VIEWS_DLL_MDB=$(BUILD_DIR)/Views.dll.mdb
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Debug/ViewModels.dll
VIEWMODELS_DLL_MDB_SOURCE=../ViewModels/bin/Debug/ViewModels.dll.mdb
VIEWMODELS_DLL_MDB=$(BUILD_DIR)/ViewModels.dll.mdb

endif

if ENABLE_RELEASE_X86
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Release/Views.dll \
	../ViewModels/bin/Release/ViewModels.dll
BUILD_DIR = bin/Release

APPMANIFEST_XAML_SOURCE=appmanifest.xaml
VIEWS_DLL_SOURCE=../Views/bin/Debug/Views.dll
VIEWS_DLL_MDB_SOURCE=../Views/bin/Debug/Views.dll.mdb
VIEWS_DLL_MDB=$(BUILD_DIR)/Views.dll.mdb
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Debug/ViewModels.dll
VIEWMODELS_DLL_MDB_SOURCE=../ViewModels/bin/Debug/ViewModels.dll.mdb
VIEWMODELS_DLL_MDB=$(BUILD_DIR)/ViewModels.dll.mdb

endif

if ENABLE_DEBUG
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Debug/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Debug/Views.dll \
	../ViewModels/bin/Debug/ViewModels.dll
BUILD_DIR = bin/Debug

APPMANIFEST_XAML_SOURCE=appmanifest.xaml
VIEWS_DLL_SOURCE=../Views/bin/Debug/Views.dll
VIEWS_DLL_MDB_SOURCE=../Views/bin/Debug/Views.dll.mdb
VIEWS_DLL_MDB=$(BUILD_DIR)/Views.dll.mdb
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Debug/ViewModels.dll
VIEWMODELS_DLL_MDB_SOURCE=../ViewModels/bin/Debug/ViewModels.dll.mdb
VIEWMODELS_DLL_MDB=$(BUILD_DIR)/ViewModels.dll.mdb

endif

if ENABLE_RELEASE
ASSEMBLY_COMPILER_COMMAND = gmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/XamlPreviewer.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = winexe
PROJECT_REFERENCES =  \
	../Views/bin/Release/Views.dll \
	../ViewModels/bin/Release/ViewModels.dll
BUILD_DIR = bin/Release

APPMANIFEST_XAML_SOURCE=appmanifest.xaml
VIEWS_DLL_SOURCE=../Views/bin/Release/Views.dll
VIEWS_DLL_MDB=
VIEWMODELS_DLL_SOURCE=../ViewModels/bin/Release/ViewModels.dll
VIEWMODELS_DLL_MDB=

endif

AL=al2
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(APPMANIFEST_XAML) \
	$(VIEWS_DLL) \
	$(VIEWS_DLL_MDB) \
	$(VIEWMODELS_DLL) \
	$(VIEWMODELS_DLL_MDB)  

BINARIES = \
	$(XAMLPREVIEWER)  


RESGEN=resgen2
	
all: $(ASSEMBLY) $(PROGRAMFILES) $(BINARIES) 

FILES = \
	gtk-gui/generated.cs \
	MainWindow.cs \
	gtk-gui/MainWindow.cs \
	Main.cs \
	AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = \
	gtk-gui/gui.stetic 

EXTRAS = \
	appmanifest.xaml \
	xamlpreviewer.in 

REFERENCES =  \
	System \
	Mono.Posix \
	$(MOONLIGHT_DESKTOP_40_LIBS) \
	$(GTKSOURCEVIEW2_SHARP_LIBS) \
	$(GTK_SHARP_20_LIBS) \
	$(GLIB_SHARP_20_LIBS) \
	$(GLADE_SHARP_20_LIBS) \
	$(MONOMOONDESKVIEWLOADER_LIBS) \
	$(MONOMOONDESKMOONWINDOW_LIBS) \
	$(MONOMOONDESKCOMMANDS_LIBS) \
	$(MOONLIGHT_GTK_40_LIBS)

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(BINARIES) 

include $(top_srcdir)/Makefile.include

APPMANIFEST_XAML = $(BUILD_DIR)/appmanifest.xaml
VIEWS_DLL = $(BUILD_DIR)/Views.dll
VIEWMODELS_DLL = $(BUILD_DIR)/ViewModels.dll
XAMLPREVIEWER = $(BUILD_DIR)/xamlpreviewer

$(eval $(call emit-deploy-target,APPMANIFEST_XAML))
$(eval $(call emit-deploy-target,VIEWS_DLL))
$(eval $(call emit-deploy-target,VIEWS_DLL_MDB))
$(eval $(call emit-deploy-target,VIEWMODELS_DLL))
$(eval $(call emit-deploy-target,VIEWMODELS_DLL_MDB))
$(eval $(call emit-deploy-wrapper,XAMLPREVIEWER,xamlpreviewer,x))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'

$(ASSEMBLY_MDB): $(ASSEMBLY)

$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	mkdir -p $(shell dirname $(ASSEMBLY))
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
