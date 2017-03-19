#!/bin/sh
set -eu

# arg: prompt
ask() {
  read -p "$1" choice
}

RELEASE_DIR="../Release"
BIN_DIR="../PSLauncher/bin/Release"

ask "Version: "

VERSION=$choice

echo "Making release for version $VERSION"

OUTPUT_FOLDER="PSForever_Launcher_$VERSION"
OUTPUT_PATH="${RELEASE_DIR}/${OUTPUT_FOLDER}"

mkdir -p ${OUTPUT_PATH}

# Copy files
cp "$BIN_DIR/"*.dll "$BIN_DIR/"*.exe ${OUTPUT_PATH}
cp "../README.md" ${OUTPUT_PATH}
mv "${OUTPUT_PATH}/README.md" "${OUTPUT_PATH}/README.txt"

echo "==== Releasing contents ===="
ls -la ${OUTPUT_PATH}
echo "============================"

# ZIP release
ZIP_FILE="${OUTPUT_FOLDER}.zip"
echo "ZIPing release to ${ZIP_FILE}"

cd ${RELEASE_DIR}
zip -r "${ZIP_FILE}" "${OUTPUT_FOLDER}"
echo "ZIP done"
ls -lh "${ZIP_FILE}"

echo "Release complete!"
exit 0
